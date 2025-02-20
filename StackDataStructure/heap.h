#pragma once
#include <string>
#include <iostream>
#include <vector>
#include <string>
#include<math.h>
#include<cmath>


void swap(int& x, int& y) {
    int temp = x;
    x = y;       
    y = temp;   
}

// MinHeap class definition
class minHeap {
public:
    minHeap(int size); 
    ~minHeap();

    int parent(int i) { return (i / 2) + 1; }
    int left(int i) { return 2 * i + 1; }
    int right(int i) { return 2 * i + 2; }

    
    int searchElementIndex(int x);
    int searchElement(int x);
    int searchParent(int x);
    int searchChildL(int x);
    int searchChildR(int x);
    void heapify(int x);
    void decreaseKey(int i, int new_val);

    //usable operations
    int extractMin();
    int getMin();
    void insertElement(int x);
    void deleteElement(int index);
   

    std::string returnTree(int& heap);
    int height();
    


private:
   int* heap; 
   int size;
   int count;
};

minHeap::minHeap(int size) {
    count = 0;
    this->size = size;
    heap = new int[size];
}

minHeap::~minHeap() {
    delete[] heap;
}

void minHeap::heapify(int x) {
    int l = left(x);
    int r = right(x);
    int smallest = x;

    if (l < count && heap[l] < heap[x])smallest = l;
    if (r < count && heap[r] < heap[x])smallest = r;
    if (smallest != x) {
        swap(heap[x], heap[smallest]);
        heapify(smallest);
    }
};

int minHeap::searchElementIndex(int x) {
    for (int i = 0;i < size;i++) {
        if (heap[i] == x) return i;
    }
    return -1;
}

int minHeap::searchElementIndex(int x) {
    for (int i = 0;i < size;i++) {
        if (heap[i] == x) return heap[i];
    }
    return -1;
}

int minHeap::searchParent(int x) {
   
    return parent(searchElementIndex(x));
}

int minHeap::searchChildL(int x) {    
    return left(searchElementIndex(x));
}

int minHeap::searchChildR(int x) {
    return right(searchElementIndex(x));
}

int minHeap::getMin() {

}

std::string minHeap::returnTree(int& heap) {

    std::string arr;
    std::string temp;
   

    for (int i = 0;i < count;i++) {
        temp = std::to_string(heap[i]);
        arr = arr + temp + " ->";
    }

    return arr;

}

int minHeap::height() {
    return static_cast<int>(ceil(log2(count + 1))-1);
}

void minHeap::insertElement(int x) {
    if (count == size) {
        std::cout << "HEAP FULL" << std::endl;
        return;
    }

    count++;
    int i = count - 1;
    heap[i] = x;

    while (i != 0 && heap[parent(i)] > heap[i]) {
        swap(heap[i], heap[parent(i)]);
        i = parent(i);
    }

}

int minHeap::extractMin() {
    if (count <= 0) return INT_MAX;
    if (count == 1) {
        count--;
        return heap[0];
    }

    int root = heap[0];
    heap[0] = heap[count - 1];
    count--;
    heapify(0);
    return root;
}

void minHeap::decreaseKey(int i, int new_val)
{
    heap[i] = new_val;
    while (i != 0 && heap[parent(i)] > heap[i]) {
        swap(heap[i], heap[parent(i)]);
        i = parent(i);
    }
}

void minHeap::deleteElement(int index) {
    decreaseKey(index, INT_MIN);
    extractMin();
}









