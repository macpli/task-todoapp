"use client";
import { useState, useEffect } from "react";
import { getTodos, addTodo, updateTodo, deleteTodo } from "../lib/api";
import { TodoItem } from "@/types/TodoItem";

import { Circle, CircleCheckBig, Trash2 } from "lucide-react"

export default function Home() {
  const [todos, setTodos] = useState<TodoItem[]>([]);
  const [newTodo, setNewTodo] = useState<string>("");
  const [error, setError] = useState<string>("");
  const [editingId, setEditingId] = useState<string | null>(null);
  const [editingTitle, setEditingTitle] = useState<string>("");

  useEffect(() => {
    loadTodos();
  }, []);

  const loadTodos = async () => {
    const todos = await getTodos();
    const sortedTodos = todos.sort((a: { isCompleted: any; }, b: { isCompleted: any; }) => Number(a.isCompleted) - Number(b.isCompleted));
    setTodos(sortedTodos);
  };

  const handleAddTodo = async () => {
    if (!newTodo.trim()) {
      setError("Task cannot be empty");
      return;
    }

    const todo: TodoItem = {
      id: crypto.randomUUID(), 
      title: newTodo,
      isCompleted: false,
    };

    await addTodo(todo);
    setNewTodo("");
    setError("");
    loadTodos();
  };

  async function handleToggleComplete(todo: TodoItem) {
    const updatedTodo: TodoItem = {
      ...todo,
      isCompleted: !todo.isCompleted,
    };
    await updateTodo(updatedTodo);
    loadTodos();
  }

  async function handleDelete(id: string) {
    await deleteTodo(id);
    loadTodos();
  }

  const handleEdit = (todo: TodoItem) => {
    if (todo.id) {
      setEditingId(todo.id);
    }
    setEditingTitle(todo.title);
  };

  async function handleRename(todo: TodoItem) {
    if (!editingTitle.trim()) {
      setError("Task name cannot be empty");
      return;
    }

    const updatedTodo: TodoItem = { ...todo, title: editingTitle };
    await updateTodo(updatedTodo);
    setEditingId(null);
    setEditingTitle("");
    setError("");
    loadTodos();
  }

  return (
    <div className="min-h-screen flex items-center justify-center bg-gray-100">
      <div className="bg-white shadow-lg rounded-lg p-6 w-full max-w-md">
        <h1 className="text-2xl font-bold text-gray-800 mb-4 text-center">Todo List</h1>

        {/* Input Field */}
        <div className="flex mb-4">
          <input
            type="text"
            value={newTodo}
            onChange={(e) => setNewTodo(e.target.value)}
            placeholder="New task..."
            className="flex-grow px-4 py-2 border border-gray-300 rounded-l-md focus:outline-none focus:ring-2 focus:ring-blue-400"
          />
          <button
            onClick={handleAddTodo}
            className="bg-blue-500 text-white px-4 py-2 rounded-r-md hover:bg-blue-600 transition"
          >
            Add
          </button>
        </div>
        {error && <p className="text-red-500 mb-4">{error}</p>}

        <h2 className="text-sm text-gray-300 mb-1">Click a task name to edit</h2>
        {/* Task List */}
        <ul className="space-y-3">
          {todos.map((todo: TodoItem) => (
            <li
              key={todo.id}
              className="flex justify-between items-center bg-gray-50 px-4 py-2 rounded-md shadow-sm border"
            >
              
              {/* Editable Title */}
              {editingId === todo.id ? (
                <input
                  type="text"
                  value={editingTitle}
                  onChange={(e) => setEditingTitle(e.target.value)}
                  onBlur={() => handleRename(todo)}
                  onKeyDown={(e) => e.key === "Enter" && handleRename(todo)}
                  className="flex-grow px-2 py-1 border rounded-md focus:ring-2 focus:ring-blue-400"
                  autoFocus
                />
              ) : (
                <div className="flex items-center gap-2">
                  {/* Toggle Complete */}
                  <button
                    onClick={() => handleToggleComplete(todo)}
                    className={`px-2 py-1 text-white rounded transition ${
                      todo.isCompleted ? "bg-gray-500 hover:bg-gray-600" : "bg-green-500 hover:bg-green-600"
                    }`}
                  >
                    {todo.isCompleted ? <CircleCheckBig /> : <Circle />}
                  </button>
                  
                  <span
                    className={`cursor-pointer ${todo.isCompleted ? "line-through text-gray-400" : "text-gray-800"}`}
                    onClick={() => handleEdit(todo)}
                  >
                    {todo.title}
                  </span>
               </div>
              )}

              <div className="flex gap-2">
                
                {/* Delete Task */}
                <button
                  onClick={() => todo.id && handleDelete(todo.id)}
                  className="text-red-500 hover:text-red-700 transition"
                >
                  <Trash2 />
                </button>
              </div>
            </li>
          ))}
        </ul>
      </div>
    </div>
  );
}
