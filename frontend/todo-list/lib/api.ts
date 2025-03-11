import { TodoItem } from "@/types/TodoItem";

const API_URL = 'http://localhost:5020/api/Todo';

export async function getTodos() {
    const resposne = await fetch(API_URL);
    return resposne.json();
}

export async function addTodo(todoItem: TodoItem) {
    const response = await fetch(API_URL, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(todoItem),
    });
    return response.json();
}

export async function updateTodo(todoItem: TodoItem) {
    const response = await fetch(`${API_URL}/${todoItem.id}`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(todoItem),
    });
}

export async function deleteTodo(id: string) {
    const response = await fetch(`${API_URL}/${id}`, {
        method: 'DELETE',
    });
}