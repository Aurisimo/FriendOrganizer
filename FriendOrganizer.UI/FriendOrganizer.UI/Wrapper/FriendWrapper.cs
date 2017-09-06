using FriendOrganizer.Model;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FriendOrganizer.UI.Wrapper
{
    public class FriendWrapper : ModelWrapper<Friend>
    {
        public int Id
        {
            get { return Model.Id; }
            set
            {
                Model.Id = value;
            }
        }

        public string FirstName
        {
            get { return GetValue<string>(nameof(FirstName)); }
            set
            {
                SetValue(value);
            }
        }

        public string LastName
        {
            get { return GetValue<string>(nameof(LastName)); }
            set
            {
                SetValue(value);
            }
        }

        public string Email
        {
            get { return GetValue<string>(nameof(Email)); }
            set
            {
                SetValue(value);
            }
        }

        public FriendWrapper(Friend model) : base(model)
        {
        }

        protected override IEnumerable<string> ValidateProperty(string propertyName)
        {
            switch (propertyName)
            {
                case nameof(FirstName):
                    if (!string.IsNullOrEmpty(FirstName) &&
                        FirstName.Equals("robot", StringComparison.OrdinalIgnoreCase))
                    {
                        yield return "Friends are not allowed to be robots";
                    }

                    break;
            }
        }
    }
}
