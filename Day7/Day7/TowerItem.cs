using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoreLinq;

namespace Day7
{
    public class TowerItem
    {
        public String _name;
        public int _value;
        public List<String> _childrenNames;
        public List<TowerItem> _children;
        public TowerItem _parent;
        public int _sumOfChildren = -1;
        public int _goodValueOfChild = -1;
        public int _level = -1;

        public TowerItem(String name, int value, List<String> childrenNames)
        {
            _children = new List<TowerItem>();
            _name = name;
            _value = value;
            _childrenNames = childrenNames;
        }

        public void SetHierarchy(List<TowerItem> list)
        {
            foreach (var name in _childrenNames)
            {
                foreach (var item in list)
                {
                    if (name == item._name)
                    {
                        _children.Add(item);
                        item.SetParent(this);
                        break;
                    }
                }
            }
        }

        public void SetParent(TowerItem parent)
        {
            _parent = parent;
        }

        public void SetSumOfChildren()
        {
            _sumOfChildren = 0;
            foreach (var item in _children)
            {
                _sumOfChildren += item._sumOfChildren;
            }
            _sumOfChildren += _value;
        }

        public int IndexOfBadChildren()
        {
            var indexOfBad = -1;
            if (_children.Count > 0)
            {
                var min = _children.MinBy(p => p._sumOfChildren);
                var max = _children.MaxBy(p => p._sumOfChildren);
                if (min._sumOfChildren != max._sumOfChildren)
                {
                    if ((_sumOfChildren-_value)/3 > (double)(min._sumOfChildren * _children.Count))
                    {
                        _goodValueOfChild = max._sumOfChildren;
                        return _children.IndexOf(min);
                    }
                    else
                    {
                        _goodValueOfChild = min._sumOfChildren;
                        return _children.IndexOf(max);
                    }
                }
                else
                {
                    _goodValueOfChild = max._sumOfChildren;
                    return indexOfBad;
                }
            }
            else
            {
                _goodValueOfChild = -1;
                return indexOfBad;
            }
        }
    }
}
