#include<string>
#include <iostream>

class Stack {
public:
	Stack(int size);
	~Stack();
	void push(int x);
	int pop();
	int peek();
	bool stackIsEmpty();
	bool stackIsFull();
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

bool Stack::stackIsEmpty() {
	if (pointer == -1) return true;
	return false;
}

bool Stack::stackIsFull() {
	if (pointer == count) return true;
	return false;
}

int Stack::getCount() {
	return count;
}



