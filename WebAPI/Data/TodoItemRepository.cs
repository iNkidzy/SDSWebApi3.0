using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebAPI.data;
using WebAPI.Models;

namespace WebAPI.Data
{
    public class TodoItemRepository:IRepository<TodoItem>
    {
        private readonly sdsDBcontext db;
        public TodoItemRepository(sdsDBcontext context)
        {
            db = context;
        }

        public void Add(TodoItem entity)
        {
            db.TodoItems.Add(entity);
            db.SaveChanges();
        }

        public void Edit(TodoItem entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }

        public TodoItem Get(long id)
        {
            return db.TodoItems.FirstOrDefault(b => b.Id == id);
        }

        public IEnumerable<TodoItem> GetAll()
        {
            return db.TodoItems.ToList();
        }

            public void Remove(long id)
        {
            var item = db.TodoItems.FirstOrDefault(b => b.Id == id);
            db.TodoItems.Remove(item);
            db.SaveChanges();
        }
    }
}
