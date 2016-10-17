using System;

namespace ConsumingOData.StackOverflowReference
{
    public partial class User : global::System.ComponentModel.INotifyPropertyChanged
    {
        const string iconPath = "http://www.gravatar.com/avatar/{0}?d=identicon&s=64";

        public string IconPath
        {
            get { return String.Format(iconPath, this.EmailHash); }
        }
    }
}
