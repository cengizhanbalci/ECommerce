using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.CacheManager
{
    public interface ICacheManager
    {
        bool Contains(string key);
        void Add<T>(string key, T source, int duration);
        void Add<T>(string key, T source);
        T Get<T>(string key);
        void Remove(string key);
    }
}
