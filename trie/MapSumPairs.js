import Trie from './Trie';

/* 677. Map Sum Pairs

Input: insert("apple", 3), Output: Null
Input: sum("ap"), Output: 3
Input: insert("app", 2), Output: Null
Input: sum("ap"), Output: 5

For the method sum, you'll be given a string representing the prefix,
and you need to return the sum of all the pairs' value whose key starts with the prefix.


*/

/**
 * Initialize your data structure here.
 */
export default class MapSum {
    constructor() {
        this.trie = new Trie();
    }

    /**
     * @param {string} key
     * @param {number} val
     * @return {void}
    */
    insert(key, val) {
        this.trie.insert(key, val);
    }

    /**
     * @param {string} prefix
     * @return {number}
     */
    sum(prefix) {
        return this.trie.getSumByPrefix(prefix);
    }
}


/**
 * Your MapSum object will be instantiated and called as such:
 * var obj = Object.create(MapSum).createNew()
 * obj.insert(key,val)
 * var param_2 = obj.sum(prefix)
 */
