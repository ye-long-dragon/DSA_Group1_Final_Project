#pragma once
#include "heap.h"
#include "stack.h"
#include "hashtable.h"
#include "dequeue.h"


/*
-----------STACK-----------
*/
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

extern "C" __declspec(dllexport) bool stackIsEmpty(Stack* s) {
	return s->stackIsEmpty();
}

extern "C" __declspec(dllexport) bool stackIsFull(Stack* s) {
	return s->stackIsFull();
}

extern "C" __declspec(dllexport) int getCount(Stack* s) {
	return s->getCount();
}

