namespace BusinessLogic;
readonly record struct UserInfo
(
     long Id,
     string FirstName,
     string LastName,
     string? Email,
     DateTime RegDate
);
