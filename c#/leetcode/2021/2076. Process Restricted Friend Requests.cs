public class Solution {
    
      public class UnionFind {
            private int[] parent;
            Random rnd = new Random();
            public UnionFind(int n) {
                parent = new int[n];

                for(int i = 0; i < parent.Length; i++) {
                    parent[i] = i;
                }
            }

            public int Find(int u) {
                while(u != parent[u]) {
                    parent[u] = parent[parent[u]];
                    u = parent[u];
                }

                return u;
            }

            public bool Connected(int u, int v) {
                return Find(u) == Find(v);
            }

            public void Union(int u, int v) {
                int value = rnd.Next(2);

                if(value == 1) {
                    int temp = u;
                    u = v;
                    v = temp;
                }

                parent[Find(u)] = Find(v);
            }
        }
    
     public bool[] FriendRequests(int n, int[][] restrictions, int[][] requests) {
            bool[] res = new bool[requests.GetLength(0)];

            var uf = new UnionFind(n);

            for(int i = 0; i < requests.GetLength(0); i++) {
                int[] req = requests[i];

                bool valid = true;
                if(!uf.Connected(req[0], req[1])) {
                    int u = uf.Find(req[0]), v = uf.Find(req[1]);
                    
                    for(int k = 0; k < restrictions.GetLength(0); k++) {
                        int[] restr = restrictions[k];

                        int x = uf.Find(restr[0]), y = uf.Find(restr[1]);

                        if((u == x && v == y) || (u == y && v == x)) {
                            valid = false;
                            break;
                        }
                    }
                }

                if(valid) {
                    uf.Union(req[0], req[1]);
                    res[i] = true;
                }
            }

            return res;
        }
}