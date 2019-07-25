using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Brusher
{
    public class PointModel : SimpleViewModel
    {
        int _X;
        public int X
        {
            get { return _X; }
            set
            {
                this.SetPropertyValue(ref _X, value, () => X);
            }
        }

        int _Y;
        public int Y
        {
            get { return _Y; }
            set
            {
                this.SetPropertyValue(ref _Y, value, () => Y);
            }
        }

        public int StValueX { get; set; }
        public int StValueY { get; set; }

        public void SetValue()
        {
            global::InputAction.MouseMove.SetMouseScreenLocation(new Point(StValueX, StValueY));
        }

    }


    public class SimpleViewModel : INotifyPropertyChanged
    {
        #region
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// This is used to set a specific value for a property.
        /// </summary>
        /// <typeparam name="T">Type to set</typeparam>
        /// <param name="storageField">Storage field</param>
        /// <param name="newValue">New value</param>
        /// <param name="propExpr">Property expression</param>
        protected bool SetPropertyValue<T>(ref T storageField, T newValue, Expression<Func<T>> propExpr)
        {
            if (Object.Equals(storageField, newValue))
                return false;
            storageField = newValue;
            var prop = (PropertyInfo)((MemberExpression)propExpr.Body).Member;
            InitProperyChangedEvent();
            PropertyChanged(this, new PropertyChangedEventArgs(prop.Name));
            return true;
        }

        private void InitProperyChangedEvent()
        {
            if (PropertyChanged == null)
                PropertyChanged = delegate { };
        }
        #endregion
    }
}
