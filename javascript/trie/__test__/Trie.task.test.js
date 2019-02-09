import Trie from '../Trie';
import longestWord from '../LongestWordInDictionary';
import MapSum from '../MapSumPairs';

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

    describe('Map Sum Pairs', () => {
        it('test 1', () => {
            const mapSum = new MapSum();
            mapSum.insert('apple', 3);
            mapSum.insert('apttt', 2);
            mapSum.insert('ananas', 2);


            expect(mapSum.sum('a')).toBe(7);
        });

        it('test 2', () => {
            const mapSum = new MapSum();
            mapSum.insert('apple', 3);
            expect(mapSum.sum('ap')).toBe(3);

            mapSum.insert('app', 2);
            expect(mapSum.sum('ap')).toBe(5);
        });

        it('test 3', () => {
            const mapSum = new MapSum();
            mapSum.insert('a', 3);
            expect(mapSum.sum('ap')).toBe(0);

            mapSum.insert('b', 2);
            expect(mapSum.sum('a')).toBe(3);
        });


        it('test 4', () => {
            const mapSum = new MapSum();
            mapSum.insert('aa', 3);
            expect(mapSum.sum('a')).toBe(3);

            mapSum.insert('aa', 2);
            expect(mapSum.sum('a')).toBe(2);
            expect(mapSum.sum('aa')).toBe(2);

            mapSum.insert('aaa', 3);
            expect(mapSum.sum('aaa')).toBe(3);
            expect(mapSum.sum('bbb')).toBe(0);
            expect(mapSum.sum('ccc')).toBe(0);

            mapSum.insert('aewfwaefjeoawefjwoeajfowajfoewajfoawefjeowajfowaj', 111);
            expect(mapSum.sum('aa')).toBe(5);
            expect(mapSum.sum('a')).toBe(116);
        });
    });
});
