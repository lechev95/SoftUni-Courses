﻿using LibraryManagementSystem.Controllers;
using LibraryManagementSystem.Core.Constants;
using LibraryManagementSystem.Extensions;
using LibraryManagementSystem_FinalWebProject.Core.Contracts;
using LibraryManagementSystem_FinalWebProject.Core.Models.Book;
using LibraryManagementSystem_FinalWebProject.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem_FinalWebProject.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        private readonly IBookService bookService;
        private readonly ILibrarianService librarianService;

        public BookController(
            IBookService _bookService,
            ILibrarianService _librarianService)
        {
            bookService = _bookService;
            librarianService = _librarianService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> All([FromQuery]AllBooksQueryModel query)
        {
            var result = await bookService.All(
                query.Genre,
                query.SearchTerm,
                query.Author,
                query.Sorting,
                query.CurrentPage,
                AllBooksQueryModel.BooksPerPage);

            query.TotalBooksCount = result.TotalBooksCount;
            query.Genres = await bookService.AllGenresNames();
            query.Authors = await bookService.AllAuthorsNames();
            query.Books = result.Books;

            return View(query);
        }

        public async Task<IActionResult> Mine()
        {
            IEnumerable<BookServiceModel> myBooks;
            var userId = User.Id();

            if (await librarianService.ExistsById(userId))
            {
                int librarianId = await librarianService.GetLibrarianId(userId);
                myBooks = await bookService.AllBooksByLibrarianId(librarianId);
            }
            else
            {
                myBooks = await bookService.AllBooksByUserId(userId);
            }

            return View(myBooks);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            if ((await bookService.BookExists(id)) == false)
            {
                TempData[MessageConstant.ErrorMessage] = "Страницата не съществува";
                return RedirectToAction(nameof(All));
            }

            var model = await bookService.BookDetailsById(id);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            if (await librarianService.ExistsById(User.Id()) == false)
            {
                TempData[MessageConstant.ErrorMessage] = "Акаунтът ви няма необходимите права за извършване на това действие";

                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).Replace("Controller", string.Empty));
            }

            var model = new BookModel()
            {
                Genres = await bookService.AllGenres(),
                Authors = await bookService.AllAuthors(),
                Publishers = await bookService.AllPublishers()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(BookModel model)
        {
            if (await librarianService.ExistsById(User.Id()) == false)
            {
                TempData[MessageConstant.ErrorMessage] = "Акаунтът ви няма необходимите права за извършване на това действие";

                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).Replace("Controller", string.Empty));
            }

            if ((await bookService.GenreExists(model.GenreId)) == false)
            {
                ModelState.AddModelError(nameof(model.GenreId), "Жанрът не съществува");
            }

            if ((await bookService.AuthorExists(model.AuthorId)) == false)
            {
                ModelState.AddModelError(nameof(model.AuthorId), "Авторът не съществува");
            }

            if ((await bookService.PublisherExists(model.PublisherId)) == false)
            {
                ModelState.AddModelError(nameof(model.PublisherId), "Издателят не съществува");
            }

            if (!ModelState.IsValid)
            {
                model.Genres = await bookService.AllGenres();
                model.Authors = await bookService.AllAuthors();
                model.Publishers = await bookService.AllPublishers();

                return View(model);
            }

            int librarianId = await librarianService.GetLibrarianId(User.Id());

            int id = await bookService.Create(model, librarianId);

            return RedirectToAction(nameof(Details), new { id });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if ((await bookService.BookExists(id)) == false)
            {
                return RedirectToAction(nameof(All));
            }

            if ((await bookService.HasLibrarianWithId(id, User.Id())) == false)
            {
                TempData[MessageConstant.WarningMessage] = "Нямате нужните права, за да достъпите съотвения ресурс";
                return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            }

            var book = await bookService.BookDetailsById(id);
            var genreId = await bookService.GetBookGenreId(id);
            var publisherId = await bookService.GetBookPublisherId(id);
            var authorId = await bookService.GetBookAuthorId(id);

            var model = new BookModel()
            {
                Id = id,
                Description = book.Description,
                Title = book.Title,
                ImageUrl = book.ImageUrl,
                Price = book.Price,
                Quantity = book.Quantity,
                GenreId = genreId,
                PublisherId = publisherId,
                AuthorId = authorId,
                Genres = await bookService.AllGenres(),
                Authors = await bookService.AllAuthors(),
                Publishers = await bookService.AllPublishers()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id,BookModel model)
        {
            if (id != model.Id)
            {
                return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            }

            if ((await bookService.BookExists(model.Id)) == false)
            {
                ModelState.AddModelError("", "Книгата не съществува!");
                TempData[MessageConstant.ErrorMessage] = "Книгата не съществува!";
                model.Genres = await bookService.AllGenres();
                model.Authors = await bookService.AllAuthors();
                model.Publishers = await bookService.AllPublishers();

                return View(model);
            }

            if ((await bookService.HasLibrarianWithId(model.Id, User.Id())) == false)
            {
                TempData[MessageConstant.WarningMessage] = "Нямате нужните права, за да достъпите съотвения ресурс";
                return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            }

            if ((await bookService.GenreExists(model.GenreId)) == false)
            {
                ModelState.AddModelError(nameof(model.GenreId), "Жанрът не съществува!");
                model.Genres = await bookService.AllGenres();
                model.Authors = await bookService.AllAuthors();
                model.Publishers = await bookService.AllPublishers();

                TempData[MessageConstant.ErrorMessage] = "Жанрът не съществува!";

                return View(model);
            }

            if ((await bookService.PublisherExists(model.PublisherId)) == false)
            {
                ModelState.AddModelError(nameof(model.PublisherId), "Издателят не съществува!");
                model.Genres = await bookService.AllGenres();
                model.Authors = await bookService.AllAuthors();
                model.Publishers = await bookService.AllPublishers(); TempData[MessageConstant.ErrorMessage] = "Издателят не съществува!";

                return View(model);
            }

            if ((await bookService.AuthorExists(model.AuthorId)) == false)
            {
                ModelState.AddModelError(nameof(model.AuthorId), "Авторът не съществува!");
                model.Genres = await bookService.AllGenres();
                model.Authors = await bookService.AllAuthors();
                model.Publishers = await bookService.AllPublishers();

                return View(model);
            }

            if (ModelState.IsValid == false)
            {
                model.Genres = await bookService.AllGenres();
                model.Authors = await bookService.AllAuthors();
                model.Publishers = await bookService.AllPublishers();

                return View(model);
            }

            await bookService.Edit(model.Id, model);

            return RedirectToAction(nameof(Details), new { model.Id });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> Rent(int id)
        {
            return RedirectToAction(nameof(Mine));
        }

        [HttpPost]
        public async Task<IActionResult> Return(int id)
        {
            return RedirectToAction(nameof(Mine));
        }
    }
}
