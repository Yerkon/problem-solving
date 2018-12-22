import Trie from '../Trie';

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

  // ["search","search","search","search","search","search","search","search","search","startsWith","startsWith","startsWith","startsWith","startsWith","startsWith","startsWith","startsWith","startsWith"]
  // [["apps"],["app"],["ad"],["applepie"],["rest"],["jan"],["rent"],["beer"],["jam"],["apps"],["app"],["ad"],["applepie"],["rest"],["jan"],["rent"],["beer"],["jam"]]
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
});
