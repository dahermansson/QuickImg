using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuickImg.Models
{
  public class Img
  {
    public Img()
    {

    }

    public Img(byte[] imgBytes, int maxShow = 2)
    {
      Id = Guid.NewGuid();
      ImgBytes = imgBytes;
      MaxShow = maxShow;
      Uploaded = DateTime.Now;
      Shown = 0;
    }

    public Guid Id { get; set; }
    public DateTime Uploaded { get; set; }
    public byte[] ImgBytes { get; set; }
    public int Shown { get; set; }
    public int MaxShow { get; set; }

    public string TimeLeft
    {
      get
      {
        return (new TimeSpan(24, 0, 0) - (DateTime.Now - Uploaded)).ToString(@"hh\:mm\:ss");
      }
    }

    public string Views
    {
      get
      {
        return string.Format("{0}/{1}", Shown, MaxShow);
      }
    }
  }
}