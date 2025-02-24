#pragma once
#include "heap.h"
#include "stack.h"
#include "hashtable.h"
#include "dequeue.h"


/*
-----------STACK-----------
*/
extern "C" __declspec(dllexport) void*   createStack(int size) {
	return (void*) new Stack(size);
}

extern "C" __declspec(dllexport) void*   deleteStack(Stack* s) {
	delete s;
}

extern "C" __declspec(dllexport) void   push(Stack* s, int x) {
	return s->push(x);
}

extern "C" __declspec(dllexport) int   pop(Stack* s) {
	return s->pop();
}

extern "C" __declspec(dllexport) int   peek(Stack* s) {
	return s->peek();
}

extern "C" __declspec(dllexport) bool   stackIsEmpty(Stack* s) {
	return s->stackIsEmpty();
}

extern "C" __declspec(dllexport) bool   stackIsFull(Stack* s) {
	return s->stackIsFull();
}

extern "C" __declspec(dllexport) int   getCount(Stack* s) {
	return s->getCount();
}

/*
-----------HASHTABLE-----------
*/

extern "C" __declspec(dllexport) void*   createHashTable(int size) {
	return (void*) new hashTable(size);
}

extern "C" __declspec(dllexport)void*   deleteHashTable(hashTable* h) {
	delete h;
}

extern "C" __declspec(dllexport)void   insertItem(hashTable* h, int key, std::string item) {
	return h->insertItem(key, item);
}

extern "C" __declspec(dllexport) void   deleteItem(hashTable* h, int key) {
	return h->deleteItem(key);
}

extern "C" __declspec(dllexport)int   searchItem(hashTable* h, int key) {
	return h->searchItem(key);
}

extern "C" __declspec(dllexport) std::string   returnItem(hashTable* h, int key) {
	return h->returnItem(key);
}

/*
-----------DEQUEUE-----------
*/

extern "C" __declspec(dllexport) void*   createDequeue(int size) {
	return (void*) new dequeue(size);
}

extern "C" __declspec(dllexport) void*   deleteDequeue(dequeue* d) {
	delete d;
}

extern "C" __declspec(dllexport) bool   dequeueIsEmpty(dequeue* d) {
	return d->dequeueIsEmpty();
}

extern "C" __declspec(dllexport) bool   dequeueIsFull(dequeue* d) {
	return d->dequeueIsFull();
}

extern "C" __declspec(dllexport) void   enqueueFront(dequeue* d, int x) {
	return d->enqueueFront(x);
}

extern "C" __declspec(dllexport) void   enqueueRear(dequeue* d, int x) {
	return d->enqueueFront(x);
}

extern "C" __declspec(dllexport) int   dequeueFront(dequeue* d) {
	return d->dequeueFront();
}

extern "C" __declspec(dllexport) int   dequeueRear(dequeue* d) {
	return d->dequeueRear();
}

extern "C" __declspec(dllexport) std::string   returnDequeue(dequeue* d) {
	return d->returnDequeue();
}


/*
-----------HEAP-----------
*/

extern "C" __declspec(dllexport) void*   createHeap(int size) {
	return new minHeap(size);
}

extern "C" __declspec(dllexport)void*   deleteHeap(minHeap* h) {
	delete h;
}

extern "C" __declspec(dllexport) void   heapify(minHeap* h, int i) {
	return h->heapify(i);
}

extern "C" __declspec(dllexport) int   searchElementIndex(minHeap* h, int x) {
	return h->searchElementIndex(x);
}

extern "C" __declspec(dllexport) int   searchElement(minHeap* h, int x) {
	return h->searchElement(x);
}

extern "C" __declspec(dllexport) int   searchParent(minHeap* h, int x) {
	return h->searchParent(x);
}

extern "C" __declspec(dllexport) int   searchChildL(minHeap* h, int x) {
	return h->searchChildL(x);
}

extern "C" __declspec(dllexport) int   searchChildR(minHeap* h, int x) {
	return h->searchChildR(x);
}

extern "C" __declspec(dllexport)int   getMin(minHeap* h) {
	return h->getMin();
}

extern "C" __declspec(dllexport)std::string   returnTree(minHeap* h) {
	return h->returnTree();
}

extern "C" __declspec(dllexport)int   height(minHeap* h) {
	return h->height();
}

extern "C" __declspec(dllexport) void   insertElement(minHeap* h, int x) {
	return h->insertElement(x);
}

extern "C" __declspec(dllexport)int   extractMin(minHeap*h) {
	return h->extractMin();
}

extern "C" __declspec(dllexport) void   deleteElement(minHeap* h, int i){
	return h->deleteElement(i);
}