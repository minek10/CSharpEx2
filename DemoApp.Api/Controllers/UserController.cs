using DemoApp.Data.Enum;
using DemoApp.Data.Model;
using DemoApp.Repository.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
		private readonly IUnitOfWork _unitOfWork;

		public UserController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		#region Get All User
		[HttpGet]
		public async Task<IActionResult> Get()
		{
			try
			{
				IEnumerable<User> users = await _unitOfWork.UserRepository.Get();
				return Ok(users);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return BadRequest(ex.Message);
			}
		}
		#endregion

		#region Get All User Filter
		[HttpGet("filter")]
		public async Task<IActionResult> GetUsersFilter(string? filter, KindOfFilter kof )
		{
			try
			{
				List<User> users = await _unitOfWork.UserRepository.GetUsersFilter(filter, kof);
				return Ok(users);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return BadRequest(ex.Message);
			}
		}
		#endregion

		#region Get By ID
		[HttpGet("{userid}")]
		public async Task<IActionResult> GetById(Guid userid)
		{
			try
			{
				User user = await _unitOfWork.UserRepository.GetById(userid);
				if (user == null)
				{
					return NotFound("Aucun élément ne correspond !");
				}
				else
				{
					return Ok(user);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return BadRequest(ex.Message);
			}
		}
		#endregion

        #region Post User
        [HttpPost]
		public async Task<IActionResult> Post([FromBody] User User)
		{
			try
			{
				if (User == null)
				{
					return NotFound("Aucun élément ne correspond !");
				}
				else
				{
					await _unitOfWork.UserRepository.Post(User);
					return Ok("L'élément a bien été créé");
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return BadRequest(ex.Message);
			}
		}
		#endregion

		#region Update
		[HttpPut]
		public async Task<IActionResult> Put([FromBody] User User)
		{
			try
			{
				if (User == null)
				{
					return NotFound("Aucun élément ne correspond !");
				}
				else
				{
					await _unitOfWork.UserRepository.Put(User.Id, User);
					return Ok("L'élément a bien été modifié");
				}

			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return BadRequest(ex.Message);
			}
		}
		#endregion

		#region Soft Delete
		[HttpDelete("{userid}")]
		public async Task<IActionResult> Delete(Guid userid)
		{
			try
			{
				User User = await _unitOfWork.UserRepository.GetById(userid);
				if (User == null)
				{
					return NotFound("Aucun élément ne correspond !");
				}
				else
				{
					User.DeleteTrackingUserId = Guid.Parse("10000000-0000-0000-0000-000000000000");
					await _unitOfWork.UserRepository.Put(userid, User);
					return Ok("L'élément a bien été supprimé");
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return BadRequest(ex.Message);
			}
		}
		#endregion
	}
}
