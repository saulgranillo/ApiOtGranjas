using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Modelos;
using ClbModOT;
using ClbNegOT;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private readonly TodoContext _context;

        //estoy en develop
        public TodoItemsController(TodoContext context)
        {
            _context = context;
        }

        
        [HttpGet("CargarEquipo")]
        public List<ClsModEquipo> CargarEquipoLista()
        {
            ClsModEquipo objModel = new ClsModEquipo();
            ClsModResultado objClsModResultado = new ClsModResultado();
            List<ClsModEquipo> LstModCatEquipo = null;

            ClsNegCatOT objCatNeg = new ClsNegCatOT();
            try
            {
                LstModCatEquipo = objCatNeg.CargarEquipoLista();

                //objModResponse.lstResultado = objCatNeg.CargarEquipoLista<ClsModEquipo>(out objModResponse);


            }

            catch (Exception ex)
            {
                objClsModResultado.MsgError = ex.Message;
            }
            return LstModCatEquipo;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>> GetTodoItem(long id)
        {
            var todoItem = await _context.TodoItems.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return todoItem;
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(long id, TodoItem todoItem)
        {
            if (id != todoItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(todoItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }



        [HttpPost]
        public async Task<ActionResult<TodoItem>> PostTodoItem(TodoItem todoItem)
        {
            _context.TodoItems.Add(todoItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTodoItem), new { id = todoItem.Id }, todoItem);
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(long id)
        {
            var todoItem = await _context.TodoItems.FindAsync(id);
            if (todoItem == null)
            {
                return NotFound();
            }

            _context.TodoItems.Remove(todoItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TodoItemExists(long id)
        {
            return _context.TodoItems.Any(e => e.Id == id);
        }
    }
}
