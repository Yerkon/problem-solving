import Trie from './Trie';

/* 720. Longest Word in Dictionary

 */

/**
 * @param {string[]} words
 * @return {string}
 */
export default function longestWord(words) {
    const trie = new Trie();

    for (let i = 0; i < words.length; i++) {
        const word = words[i];
        trie.insert(word);
    }

    let idxOfLongest = null;
    let maxLength = -1;

    for (let i = 0; i < words.length; i++) {
        const word = words[i];

        if (trie.isChainedWord(word)) {
            if (maxLength < word.length) {
                maxLength = word.length;
                idxOfLongest = i;
            } else if (maxLength === word.length) {
                // found another word
                // compare two words, smallest lexicographical order
                const maxWord = words[idxOfLongest];

                for (let k = 0; k < word.length; k++) {
                    if (maxWord[k] < word[k]) {
                        break;
                    } else if (maxWord[k] > word[k]) {
                        idxOfLongest = i;
                        break;
                    }
                }
            }
        }
    }

    return words[idxOfLongest];
}
