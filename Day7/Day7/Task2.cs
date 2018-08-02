using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7
{
    public class Task2 : Task1
    {

        public Task2(String text) : base(text)
        {

        }

        public new int Result()
        {
            int result = 0;
            TowerItem bottom = null;
            foreach (var item in _items)
            {
                item.SetHierarchy(_items);
            }
            foreach (var item in _items)
            {
                if (item._parent == null && item._children.Count != 0)
                {
                    bottom = item;
                }
            }
            SetLevels(bottom, 0);
            SetSumOfChildrenOfAll();
            if (bottom != null)
            {
                while (true)
                {
                    var index = bottom.IndexOfBadChildren();
                    if (index != -1)
                    {
                        bottom = bottom._children[index];
                    }
                    else
                    {
                        if (bottom._goodValueOfChild * bottom._children.Count != bottom._sumOfChildren)
                        {
                            if (bottom._parent != null)
                            {
                                result = bottom._parent._goodValueOfChild - bottom._goodValueOfChild * bottom._children.Count;
                                break;
                            }
                        }
                    }
                }
            }

            return result;
        }

        protected void SetSumOfChildrenOfAll()
        {
            var max = _items.Max(p => p._level);
            for (var i = max; i >= 0; --i)
            {
                var tab = _items.Where(p => p._level == i);
                foreach (var item in tab)
                {
                    item.SetSumOfChildren();
                }
            }
        }

        protected void SetLevels(TowerItem item, int level)
        {
            item._level = level;
            foreach(var i in item._children)
            {
                SetLevels(i, level+1);
            }
        }
    }
}
