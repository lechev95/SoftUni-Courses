function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);

   function onClick() {
      const tableRowElements = document.querySelectorAll('table.container tbody tr');
      const searchFieldElement = document.getElementById('searchField');
      const searchText = searchFieldElement.value;

      searchFieldElement.value = '';

      for (const tableRowElement of tableRowElements) {
         const tdElements = tableRowElement.querySelectorAll('td');
         let isSelected = false;

         tableRowElement.className = '';

         for (const tdElement of tdElements) {
            if(tdElement.textContent.includes(searchText)){
               isSelected = true;
               break;
            }
         }

         if(isSelected){
            tableRowElement.className = 'select';
         }

      }
   }
}