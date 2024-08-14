using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PdfSharp.Drawing;

namespace LeslieDoc
{
    public class PositionInfo
    {
        public XPoint Location { get; set; }
        public XSize Size { get; set; }
        public double Top
        { 
            get {
                return Location.Y;
            }
        }
        public double Bottom
        { 
            get {
                return Location.Y + Size.Height;
            }
        }
        public double Left
        { 
            get {
                return Location.X;
            }
        }
        public double Right
        { 
            get {
                return Location.X + Size.Width;
            }
        }
    }
}
