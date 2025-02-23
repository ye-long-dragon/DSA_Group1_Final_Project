#include <iostream>
#include <string>
#include <climits>
#include <cmath>

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

    int parent(int i) { return (i - 1) / 2; }
    int left(int i) { return 2 * i + 1; }
    int right(int i) { return 2 * i + 2; }

    int searchElementIndex(int x);
    int searchElement(int x);
    int searchParent(int x);
    int searchChildL(int x);
    int searchChildR(int x);
    void heapify(int i);
    void decreaseKey(int i, int new_val);

    // Usable operations
    int extractMin();
    int getMin();
    void insertElement(int x);
    void deleteElement(int index);

    std::string returnTree();
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

void minHeap::heapify(int i) {
    int smallest = i;
    int l = left(i);
    int r = right(i);

    if (l < count && heap[l] < heap[smallest])
        smallest = l;
    if (r < count && heap[r] < heap[smallest])
        smallest = r;

    if (smallest != i) {
        std::swap(heap[i], heap[smallest]);
        heapify(smallest);
    }
}

int minHeap::searchElementIndex(int x) {
    for (int i = 0; i < count; i++) { // Iterate only up to count
        if (heap[i] == x) return i;
    }
    return -1;
}

int minHeap::searchElement(int x) {
    for (int i = 0; i < count; i++) { // Iterate only up to count
        if (heap[i] == x) return heap[i];
    }
    return -1;
}

int minHeap::searchParent(int x) {
    int index = searchElementIndex(x);
    if (index == -1) return -1; // Element not found
    return heap[parent(index)];
}

int minHeap::searchChildL(int x) {
    int index = searchElementIndex(x);
    if (index == -1) return -1; // Element not found
    return heap[left(index)];
}

int minHeap::searchChildR(int x) {
    int index = searchElementIndex(x);
    if (index == -1) return -1; // Element not found
    return heap[right(index)];
}

int minHeap::getMin() {
    if (count > 0) {
        return heap[0]; // Return the minimum element
    }
    return -1; // Indicate that the heap is empty
}

std::string minHeap::returnTree() {
    std::string arr;
    for (int i = 0; i < count; i++) {
        arr += std::to_string(heap[i]);
        if (i < count - 1) arr += " -> "; // Add separator only between elements
    }
    return arr;
}

int minHeap::height() {
    return static_cast<int>(ceil(log2(count + 1)) - 1);
}

void minHeap::insertElement(int x) {
    if (count == size) {
        std::cout << "HEAP FULL" << std::endl;
        return;
    }

    // Insert the new element at the end of the heap
    heap[count] = x;
    count++;

    // Fix the min heap property if it is violated
    int i = count - 1;
    while (i != 0 && heap[parent(i)] > heap[i]) {
        swap(heap[i], heap[parent(i)]);
        i = parent(i);
    }
}

int minHeap::extractMin() {
    if (count <= 0) return INT_MAX; // Heap is empty
    if (count == 1) {
        count--;
        return heap[0]; // Return the only element
    }

    // Store the minimum value, and replace it with the last element
    int root = heap[0];
    heap[0] = heap[count - 1];
    count--;
    heapify(0); // Restore the heap property
    return root;
}

void minHeap::decreaseKey(int i, int new_val) {
    if (i < 0 || i >= count) return; // Check for valid index
    heap[i] = new_val;
    while (i != 0 && heap[parent(i)] > heap[i]) {
        std::swap(heap[i], heap[parent(i)]);
        i = parent(i);
    }
}

void minHeap::deleteElement(int index) {
    if (index < 0 || index >= count) return; // Check for valid index
    decreaseKey(index, INT_MIN); // Decrease the key to the smallest possible value
    extractMin(); // Remove the minimum element
}



