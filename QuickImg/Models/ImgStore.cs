using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuickImg.Models
{
    public static class ImgStore
    {
        private static Dictionary<Guid, Img> _store = new Dictionary<Guid, Img>();

        public static Img AddImg(byte[] bytes, int maxShow = 2)
        {
            Img img = new Img(bytes, maxShow);
            _store.Add(img.Id, img);
            return img;
        }

        public static Img GetImg(Guid id)
        {
            Img img = null;
            if (_store.TryGetValue(id, out img))
            {
                if (img.MaxShow <= img.Shown || (DateTime.Now - img.Uploaded) >= new TimeSpan(24, 0, 0))
                {
                    _store.Remove(id);
                    return null;
                }
            }
            return img;
        }

        public static bool ImgExists(Guid id)
        {
            return _store.ContainsKey(id);
        }

        public static void Show(Guid id)
        {
            if(_store.ContainsKey(id))
            {
                _store[id].Shown++;
            }
            if (_store[id].Shown >= _store[id].MaxShow)
                _store.Remove(id);
        }
    }
}