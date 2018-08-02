using MoreLinq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7
{
    public class Task1
    {
        protected List<TowerItem> _items;
        public Task1(String text)
        {
            _items = new List<TowerItem>();
            var sr = new StringReader(text);
            while (true)
            {
                var line = sr.ReadLine();
                if (line == null)
                {
                    break;
                } else
                {
                    var tmp = line.Split(' ');
                    var name = tmp[0];
                    var value = Int32.Parse(tmp[1].Remove(tmp[1].Length - 1, 1).Remove(0, 1));
                    var children = new List<String>();
                    for(var i=3; i < tmp.Length; ++i)
                    {
                        if(tmp[i].ElementAt(tmp[i].Length-1)==',')
                            children.Add(tmp[i].Remove(tmp[i].Length - 1, 1));
                        else
                            children.Add(tmp[i]);
                    }
                    _items.Add(new TowerItem(name, value, children));
                }
            }
        }

        public String Result()
        {
            String result = "";
            foreach(var item in _items)
            {
                item.SetHierarchy(_items);
            }
            foreach (var item in _items)
            {
                if (item._parent == null && item._children.Count!=0)
                {
                    result = item._name;
                    return result;
                }
            }
            
            return result;
        }

        protected TowerItem FindTowerItemWithMinValue()
        {
            return _items.MinBy(p => p._value);
        }
    }
}
