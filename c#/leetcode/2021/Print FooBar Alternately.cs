using System;
using System.Collections.Generic;
using System.Text;

namespace Project._2021 {
    class Print_FooBar_Alternately {
        public class FooBar {
            private int n;

            public FooBar(int n) {
                this.n = n;
            }

            public void Foo(Action printFoo) {

                for (int i = 0; i < n; i++) {

                    // printFoo() outputs "foo". Do not change or remove this line.
                    printFoo();
                }
            }

            public void Bar(Action printBar) {

                for (int i = 0; i < n; i++) {

                    // printBar() outputs "bar". Do not change or remove this line.
                    printBar();
                }
            }
        }
    }
}
