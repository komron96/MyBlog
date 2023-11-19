namespace BusinessLogic;
public readonly record struct UserDto
(
     long Id,
     string FirstName,
     string LastName,
     string? Email,
     DateTime RegDate
);
