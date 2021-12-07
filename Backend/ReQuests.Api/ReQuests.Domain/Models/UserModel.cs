﻿using Microsoft.EntityFrameworkCore;

namespace ReQuests.Domain.Models;

[Index( nameof( Uuid ), IsUnique = true )]
[Index( nameof( Username ), IsUnique = true )]
[Index( nameof( Email ), IsUnique = true )]
public class UserModel
{
	public UserModel( string uuid, string username, string email, string passwordHash )
	{
		Uuid = uuid;
		Username = username;
		Email = email;
		PasswordHash = passwordHash;
	}

	public int Id { get; set; }
	public string Uuid { get; set; }
	public string Username { get; set; }
	public string Email { get; set; }
	public string PasswordHash { get; set; }

	public List<TokenModel>? Tokens { get; set; }
}
