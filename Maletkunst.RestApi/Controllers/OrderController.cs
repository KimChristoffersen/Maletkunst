﻿using Maletkunst.DAL.Interfaces;
using Maletkunst.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace Maletkunst.RestApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private IOrdersDataAccess _orderMvcDao;

    public OrderController(IOrdersDataAccess orderMvcDao)
    {
        _orderMvcDao = orderMvcDao;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Order>> GetAllOrders()
    {
        var orders = _orderMvcDao.GetAllOrders();

        if (orders == null) { return NotFound(); }

        if (!orders.Any()) { return NoContent(); }

        return Ok(orders);
    }

    //[HttpGet("{id}")]
    //public string GetOrderByOrderNumber(int orderNumber)
    //{
    //    return "value";
    //}

    [HttpPost]
    public ActionResult<int> CreateOrder(Order order)
    {
        int id = _orderMvcDao.CreateOrder(order);

        if (id == 0) { return BadRequest(); }

        return Ok(id);
    }

    //[HttpPut("{id}")]
    //public void UpdateOrder(int id, [FromBody] string value)
    //{
    //}

    //[HttpDelete("{id}")]
    //public void DeleteOrder(int OrderNumber)
    //{
    //}
}
