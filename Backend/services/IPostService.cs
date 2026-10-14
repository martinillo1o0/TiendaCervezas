using System;
using backend.DTOs;
namespace backend.services;

public interface IPostService
{

	Task<IEnumerable<PostDTO>> Get();

}
