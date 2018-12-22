export default class TrieNode {
  constructor(character, isCompletedWord = false) {
    this.character = character;
    this.isCompletedWord = isCompletedWord;
    this.children = {};
  }


  /**
   * @param {string} character
   * @param {boolean} isCompletedWord
   * @return {TrieNode}
   */
  addChild(character, isCompletedWord = false) {
    if (this.children[character] && this.children[character].isCompletedWord === false) {
      this.children[character].isCompletedWord = isCompletedWord;
    } else if (!this.children[character]) {
      this.children[character] = new TrieNode(character, isCompletedWord);
    }

    return this.children[character];
  }

  /**
   * @param {string} character
   * @return {TrieNode}
   */
  getChild(character) {
    return this.children[character];
  }

  /**
   * @return {string[]}
   */
  getChildren() {
    return Object.keys(this.children);
  }
}
