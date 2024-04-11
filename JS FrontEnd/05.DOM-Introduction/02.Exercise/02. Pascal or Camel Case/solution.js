function solve() {
  const textElement = document.getElementById('text');
  const namingConventionElement = document.getElementById('naming-convention');
  const result = document.querySelector('#result');

  const text = textElement.value;
  const namingConvention = namingConventionElement.value;

  const converToPascalCase = (text) => 
    text
      .split(' ')
      .map(word => word.charAt(0).toUpperCase() + word.slice(1).toLowerCase())
      .join('');

  const convertor = {
    'Pascal Case': converToPascalCase,
    'Camel Case': (text) => converToPascalCase(text).charAt(0).toLowerCase() + converToPascalCase(text).slice(1)
  };

  if(!convertor[namingConvention]){
    result.textContent = 'Error!';
    return;
  }

  result.textContent = convertor[namingConvention](text);
}
