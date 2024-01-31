//using Domain.Enums;

//namespace Application.Common.Validators
//{
//    public static class AdminValidator
//    {
//        public static bool IsValid(this Admin admin)
//        {
//            return admin != null &&
//                   !string.IsNullOrEmpty(admin.FirstName) &&
//                   !string.IsNullOrEmpty(admin.LastName) &&
//                   !string.IsNullOrEmpty(admin.Email) &&
//                   !string.IsNullOrEmpty(admin.PhoneNumber) &&
//                   !string.IsNullOrEmpty(admin.Address) &&
//                   Enum.IsDefined(typeof(Roles), admin.Roles);
//        }

//        public static bool IsExist(this Admin admin, IEnumerable<Admin> admins)
//        {
//            return admins.All(a =>
//                a.FirstName != admin.FirstName &&
//                a.LastName != admin.LastName &&
//                a.Email != admin.Email &&
//                a.PhoneNumber != admin.PhoneNumber &&
//                a.Address != admin.Address &&
//                a.Roles != admin.Roles &&
//                a.Id != admin.Id 
//            );
//        }
//    }
//}
