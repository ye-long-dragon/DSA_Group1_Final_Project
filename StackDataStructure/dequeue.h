#pragma once
#include <string>
#include <iostream>

class dequeue {
private:
	int front;
	int rear;
	int size;
	int* arr;

public:
	dequeue(int size);
	~dequeue();
	void enqueueFront(int x);
	void enqueueRear(int x);
	int dequeueFront();
	int dequeueRear();
	bool isEmpty();
	bool isFull();

};


dequeue::dequeue(int size) {
	this->size = size;
	front = -1;
	rear = -1;
	arr = new int[size];
}

dequeue::~dequeue() {
	delete[]arr;
}

bool dequeue::isEmpty() {
	if (front == rear) return true;
	return false;
}

bool dequeue::isFull() {
	if (rear == size - 1) return true;
	return false;
}

void dequeue::enqueueFront(int x) {
	if (front == -1) std::cout << "Dequeue Overflow" << std::endl;
	else {
		arr[front] = x;
		front--;
	}
}

void dequeue::enqueueRear(int x) {
	if (isFull())std::cout << "Dequeue Overflow" << std::endl;
	else {
		rear++;
		arr[rear] = x;
	}
}

int dequeue::dequeueFront() {
	int x = -1;
	if (isEmpty())std::cout << "Dequeue Underflow" << std::endl;
	else {
		x = arr[front];
		front++;
	}
	return x;
}

int dequeue::dequeueRear() {
	int x = -1;
	if (rear == -1)std::cout << "Dequeue Underflow" << std::endl;
	else {
		x = arr[rear];
		rear--;
	}
	return x;
}

