function search() {
   const towns = document.getElementById('towns');
   const searchText = document.getElementById('searchText').value;
   const resultElement = document.getElementById('result');

   let matchCount = 0;

   const townElements = Array.from(towns.children);

   for (const townElement of townElements) {
      if(townElement.textContent.includes(searchText)){
         townElement.style.textDecoration = 'underline';
         townElement.style.fontWeight = 'bold'
         matchCount++;
      }
   }

   resultElement.textContent = `${matchCount} matches found`;
}
