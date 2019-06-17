using System;
using System.Collections.Generic;
using System.Text;

namespace NosTrinks.Domain.ViewModel
{
    public class UserDispoViewModel
    {
        public int UserId { get; set; }
        public string Name { get; set; }

        public bool? IsAvailable { get; set; }

        public static ICollection<UserDispoViewModel> ToViewModel(ICollection<UserDisponibility> userDist)
        {
            List<UserDispoViewModel> dispList = new List<UserDispoViewModel>();
            foreach (var us in userDist)
            {
                dispList.Add(new UserDispoViewModel
                {
                    Name = us.User.Name,
                    IsAvailable = us.IsAvailable == null ? false : us.IsAvailable
                });
            }

            return dispList;
        }
    }
}
