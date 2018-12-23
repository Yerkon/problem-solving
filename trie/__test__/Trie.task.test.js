import Trie from '../Trie';
import longestWord from '../LongestWordInDictionary';

/* Example:


    Trie trie = new Trie();

    trie.insert("apple");
    trie.search("apple");   // returns true
    trie.search("app");     // returns false
    trie.startsWith("app"); // returns true
    trie.insert("app");
    trie.search("app");     // returns true */

describe('Trie', () => {
  it('test', () => {
    const trie = new Trie();
    trie.insert('apple');

    expect(trie.search('apple')).toBe(true);
    expect(trie.search('app')).toBe(false);
    expect(trie.startsWith('app')).toBe(true);
    expect(trie.startsWith('app1')).toBe(false);

    trie.insert('app');
    expect(trie.search('app')).toBe(true);
  });

  it('test 2', () => {
    const trie = new Trie();
    trie.insert('apple');

    expect(trie.search('apple')).toBe(true);
    expect(trie.search('app')).toBe(false);
    expect(trie.startsWith('app')).toBe(true);

    trie.insert('app');
    expect(trie.search('app')).toBe(true);
  });

  it('test 3', () => {
    const trie = new Trie();
    trie.insert('app');
    trie.insert('apple');
    trie.insert('beer');
    trie.insert('add');
    trie.insert('jam');
    trie.insert('rental');

    expect(trie.search('apps')).toBe(false);
    expect(trie.search('app')).toBe(true);
  });

  it('Longest Word in Dictionary', () => {
    let words = ['w', 'wo', 'wor', 'worl', 'world'];

    expect(longestWord(words)).toBe('world');

    words = ['a', 'banana', 'app', 'appl', 'ap', 'apple', 'apply'];
    expect(longestWord(words)).toBe('apple');

    words = ['m', 'mo', 'moc', 'moch', 'mocha', 'l', 'la', 'lat', 'latt', 'latte', 'c', 'ca', 'cat'];
    expect(longestWord(words)).toBe('latte');

    words = ['t', 'ti', 'tig', 'tige', 'tiger', 'e', 'en', 'eng', 'engl', 'engli', 'englis', 'english', 'h', 'hi', 'his', 'hist', 'histo', 'histor', 'history'];
    expect(longestWord(words)).toBe('english');

    words = ['yo', 'ew', 'fc', 'zrc', 'yodn', 'fcm', 'qm', 'qmo', 'fcmz', 'z', 'ewq', 'yod', 'ewqz', 'y'];
    expect(longestWord(words)).toBe('yodn');
  });
});
