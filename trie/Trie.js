/*
208. Implement Trie (Prefix Tree)
Implement a trie with insert, search, and startsWith methods.

Example:

    Trie trie = new Trie();

    trie.insert("apple");
    trie.search("apple");   // returns true
    trie.search("app");     // returns false
    trie.startsWith("app"); // returns true
    trie.insert("app");
    trie.search("app");     // returns true

Note:

    You may assume that all inputs are consist of lowercase letters a-z.
    All inputs are guaranteed to be non-empty strings.

*/

import TrieNode from './TrieNode';


export default class Trie {
  constructor() {
    this.head = new TrieNode('*');
  }


  /**
   * Inserts a word into the trie.
   * @param {string} word
   * @return {void}
   */
  insert(word) {
    let currNode = this.head;

    for (let i = 0; i < word.length; i++) {
      const character = word[i];
      const isCompletedWord = i === word.length - 1;
      currNode = currNode.addChild(character, isCompletedWord);
    }
  }

  /**
   * Returns if the word is in the trie.
   * @param {string} word
   * @return {boolean}
   */
  search(word) {
    let currNode = this.head;

    for (let i = 0; i < word.length; i++) {
      const character = word[i];
      currNode = currNode.getChild(character);

      if (!currNode) return false;
    }

    return currNode.isCompletedWord;
  }

  /**
   * Returns if there is any word in the trie that starts with the given prefix.
   * @param {string} prefix
   * @return {boolean}
   */
  startsWith(prefix) {
    let currNode = this.head;

    for (let i = 0; i < prefix.length; i++) {
      const character = prefix[i];
      currNode = currNode.getChild(character);

      if (!currNode) return false;
    }

    return true;
  }
}

/**
 * Your Trie object will be instantiated and called as such:
 * var obj = Object.create(Trie).createNew()
 * obj.insert(word)
 * var param_2 = obj.search(word)
 * var param_3 = obj.startsWith(prefix)
 */
