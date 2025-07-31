const chalk = require('chalk');
const htmlhint = require('htmlhint').default;
const cheerio = require('cheerio');

const getCssFiles = require('./utils/get-css-files');
const getFileContent = require('./utils/get-file-content');
const htmlHintConfig = require('./config/htmlhint.config');

// A Utility Function to merge all the errors
const createErrorMessage = lintErrors => lintErrors.files.reduce((errorString, file) => {
  const errorsOfFile = file.messages.reduce((error, message) => {
    const errorMessage = `
      ${chalk.underline.bold(file.filename)} Line: ${chalk.bold(message.line)} Col: ${chalk.bold(message.col)} ${chalk.red(message.message)}
      ${chalk.red.bold(message.evidence)}
      Details can be found at ${message.rule.link}`;
    return [error, errorMessage].join('\n');
  }, '');
  return [errorString, errorsOfFile].join('');
},'');

describe('Css Test Cases', () => {

  test('css test', async () => {   
    const cssFiles = getCssFiles();
    const files = await cssFiles.reduce(async (errors, file) => {
    const content = await getFileContent(file);  
    console.log(content);
    const $ = cheerio.load(content);
    const productSection = $('.section.products-section');  
    expect(productSection).toBeTruthy();   
    }, { files: [], count: 0 });
  
  });   
});