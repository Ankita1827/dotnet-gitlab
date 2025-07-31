const chalk = require('chalk');
const htmlhint = require('htmlhint').default;
const cheerio = require('cheerio');

const getHtmlFiles = require('./utils/get-html-files');
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

describe('Exercise Test Cases', () => {
  test('Main section class should be container ', async () => {
    const htmlFiles = getHtmlFiles();
    const files = await htmlFiles.reduce(async (errors, file) => {
      const content = await getFileContent(file);
      const $ = cheerio.load(content);
      expect( $('body main > section').hasClass('container')).toBeTruthy();   
    }, { files: [], count: 0 });
  });
  test('Header section must be implemented using header tag with class name (header-row) ', async () => {
    const htmlFiles = getHtmlFiles();
    const files = await htmlFiles.reduce(async (errors, file) => {
    const content = await getFileContent(file);
    const $ = cheerio.load(content);
    const menulist = $('header');
    expect(menulist.is('.header-row')).toBeTruthy();
    }, { files: [], count: 0 });
  });
  test('Header should contain menus  named HOME , ABOUT US , CONTACT US , SIGN UP links ', async () => {
      const htmlFiles = getHtmlFiles();
      const files = await htmlFiles.reduce(async (errors, file) => {
      const content = await getFileContent(file);
      const $ = cheerio.load(content);
      const first = $('li').first().html(); 
      expect(first === 'HOME').toBeTruthy();
      const second = $('li').last().html(); 
      expect(second === 'SIGN UP').toBeTruthy();
    }, { files: [], count: 0 });
  });
  test('first and last  article element must have tools.png image in src', async () => {
    const htmlFiles = getHtmlFiles();
    const files = await htmlFiles.reduce(async (errors, file) => {
    const content = await getFileContent(file);
    const $ = cheerio.load(content);
    const first = $('img').first(); 
    var imageName=first.attr('src')
    expect(imageName === 'images/tools.png').toBeTruthy();   
    const last = $('img').last(); 
    imageName=last.attr('src')     
    expect(imageName).toEqual('images/management.png');  
    }, { files: [], count: 0 });
  });

  test('Article element must have class named product', async () => {
    const htmlFiles = getHtmlFiles();
    const files = await htmlFiles.reduce(async (errors, file) => {
    const content = await getFileContent(file);
    const $ = cheerio.load(content);     
    expect( $('article').hasClass('product')).toBeTruthy();      
    }, { files: [], count: 0 });
  });

  
  test('Article must have div to hold image ', async () => {
    const htmlFiles = getHtmlFiles();
    const files = await htmlFiles.reduce(async (errors, file) => {
      const content = await getFileContent(file);
      const $ = cheerio.load(content);
      expect( $('body main >section > section > article > div').hasClass('product-image')).toBeTruthy();   
    }, { files: [], count: 0 });
  });
  test('Article must have h2 to hold title ', async () => {
    const htmlFiles = getHtmlFiles();
    const files = await htmlFiles.reduce(async (errors, file) => {
      const content = await getFileContent(file);
      const $ = cheerio.load(content);
      expect( $('body main >section > section > article > h2').hasClass('product-title')).toBeTruthy();   
    }, { files: [], count: 0 });
  });
  test('Article must have p to hold description ', async () => {
    const htmlFiles = getHtmlFiles();
    const files = await htmlFiles.reduce(async (errors, file) => {
      const content = await getFileContent(file);
      const $ = cheerio.load(content);
      expect( $('body main >section > section > article > p').hasClass('product-description')).toBeTruthy();   
    }, { files: [], count: 0 });
  });
  test('Article must have Learn More link ', async () => {
    const htmlFiles = getHtmlFiles();
    const files = await htmlFiles.reduce(async (errors, file) => {
      const content = await getFileContent(file);
      const $ = cheerio.load(content,{ lowerCaseTags: true });
      const knowmore=$('body main >section > section > article > a').html();
      expect(knowmore).toEqual('LEARN MORE');  
    }, { files: [], count: 0 });
  });
  test('The seoncd menu item should be ABOUT US ', async () => {
    const htmlFiles = getHtmlFiles();
    const files = await htmlFiles.reduce(async (errors, file) => {
    const content = await getFileContent(file);
    const $ = cheerio.load(content);
    const menus=$('body main >section > header > nav > ul :nth-child(2)').html();  
    expect(menus).toEqual('ABOUT US');  
    }, { files: [], count: 0 });
  });
  it('The third menu item should be CONTACT US ', async () => {
    const htmlFiles = getHtmlFiles();
    const files = await htmlFiles.reduce(async (errors, file) => {
    const content = await getFileContent(file);
    const $ = cheerio.load(content);
    const menus=$('body main >section > header > nav > ul :nth-child(3)').html();  
    expect(menus).toEqual('CONTACT US');  
    }, { files: [], count: 0 });
  });
});