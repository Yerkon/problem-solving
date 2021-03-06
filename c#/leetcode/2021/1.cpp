
class BSTIterator
{
    stack<TreeNode *> s;
    void pushLeft(TreeNode *n)
    {
        while (n != nullptr)
            s.push(exchange(n, n->left));
    }

public:
    BSTIterator(TreeNode *root) { pushLeft(root); }
    bool hasNext() const { return !s.empty(); }
    int next()
    {
        auto n = s.top();
        s.pop();
        pushLeft(n->right);
        return n->val;
    }
};

class PeekingIterator : public BSTIterator
{
    bool peeked = false;
    int last_val = 0;

public:
    PeekingIterator(TreeNode *root) : BSTIterator(root) {}
    int peek()
    {
        if (peeked)
            return last_val;
        peeked = true;
        return last_val = BSTIterator::next();
    }
    int next()
    {
        if (peeked)
        {
            peeked = false;
            return last_val;
        }
        return BSTIterator::next();
    }
    bool hasNext() const
    {
        return peeked || BSTIterator::hasNext();
    }
};
vector<int> mergeKTrees(vector<TreeNode *> trees)
{
    vector<int> res;
    priority_queue<pair<int, PeekingIterator *>, vector<pair<int, PeekingIterator *>>, greater<pair<int, PeekingIterator *>>> q;
    for (auto t : trees)
    {
        auto it = new PeekingIterator(t);
        if (it->hasNext())
            q.push({it->peek(), it});
    }
    while (!q.empty())
    {
        auto p = q.top();
        q.pop();
        res.push_back(p.second->next());
        if (p.second->hasNext())
            q.push({p.second->peek(), p.second});
    }
    return res;
}
vector<int> getAllElements(TreeNode *root1, TreeNode *root2)
{
    return mergeKTrees({root1, root2});
}