export default class TrieNode {
    constructor(character, isCompletedWord = false, value = undefined) {
        this.character = character;
        this.value = value || 0;
        this.isCompletedWord = isCompletedWord;
        this.children = {};
    }


    /**
    * @param {string} character
    * @param {boolean} isCompletedWord
    * @param {number} value
    * @return {TrieNode}
    */
    addChild(character, isCompletedWord = false, value = undefined) {
        let child = this.children[character];

        if (child && child.isCompletedWord === false) {
            child.isCompletedWord = isCompletedWord;
        } else if (!child) {
            this.children[character] = new TrieNode(character, isCompletedWord);
            child = this.children[character];
        }

        if (isCompletedWord) {
            child.value = value;
        }

        return child;
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
