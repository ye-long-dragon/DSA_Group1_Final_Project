#include<string>
#include <iostream>

class Stack {
public:
	Stack(int size);
	~Stack();
	void push(int x);
	int pop();
	int peek();
	bool isEmpty();
	bool isFull();
	int getCount();

private:
	int pointer;
	int arr;
	int count;
};

Stack::Stack(int size) {
	this->count = size;
	int* arr = new int[size];
	this->pointer = 0;
}

Stack::~Stack() {
	delete[] arr;
}

void Stack::push(int x)
{
	if (pointer == count) {
		std::cout << "Stack Overflow: Unable to add" << std::endl;
	}
	else {
		pointer++;
		arr[pointer] = x;
	}
}

int Stack::pop() {
	if (pointer == -1) {
		std::cout << "Stack Underflow: Unable to add" << std::endl;
	}
	else {
		pointer--;
		return arr[pointer + 1];
	}
	return -1;
}

int Stack::peek() {
	if (pointer == -1) {
		std::cout << "Stack is Empty" << std::endl;
	}
	else {
		return arr[pointer];
	}
}

bool Stack::isEmpty() {
	if (pointer == -1) return true;
	return false;
}

bool Stack::isFull() {
	if (pointer == count) return true;
	return false;
}

int Stack::getCount() {
	return count;
}

extern "C" __declspec(dllexport) void* createStack(int size) {
	return (void*) new Stack(size);
}

extern "C" __declspec(dllexport) void* deleteStack(Stack* s) {
	delete s;
}

extern "C" __declspec(dllexport) void push(Stack* s, int x) {
	return s->push(x);
}

extern "C" __declspec(dllexport) int pop(Stack* s) {
	return s->pop();
}

extern "C" __declspec(dllexport) int peek(Stack* s) {
	return s->peek();
}

extern "C" __declspec(dllexport) bool isEmpty(Stack* s) {
	return s->isEmpty();
}

extern "C" __declspec(dllexport) bool isFull(Stack* s) {
	return s->isFull();
}

extern "C" __declspec(dllexport) int getCount(Stack* s) {
	return s->getCount();
}



