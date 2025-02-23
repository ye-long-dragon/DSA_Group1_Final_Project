#include <iostream>
#include <vector>
#include <string>

class Node {
public:
    int key; // Store the key
    std::string data;
    Node* next;

    Node(int k, std::string item) : key(k), data(item), next(nullptr) {}
};

class hashTable {
private:
    std::vector<Node*> programCourses; // Vector of Node pointers
    int setSize;

public:
    hashTable(int size);
    ~hashTable();
    void insertItem(int key, std::string item);
    int hashFunction(int key);
    int searchItem(int key);
    std::string returnItem(int key);
    void deleteItem(int key);
};

hashTable::hashTable(int size) : setSize(size), programCourses(size, nullptr) {}

hashTable::~hashTable() {
    for (int i = 0; i < setSize; i++) {
        Node* current = programCourses[i];
        while (current != nullptr) {
            Node* temp = current;
            current = current->next;
            delete temp; // Free memory
        }
    }
}

int hashTable::hashFunction(int key) {
    return key % setSize;
}

void hashTable::insertItem(int key, std::string item) {
    int hashIndex = hashFunction(key);
    Node* newNode = new Node(key, item);

    // Insert at the beginning of the linked list
    newNode->next = programCourses[hashIndex];
    programCourses[hashIndex] = newNode;
}

int hashTable::searchItem(int key) {
    int hashIndex = hashFunction(key);
    Node* current = programCourses[hashIndex];

    while (current != nullptr) {
        if (current->key == key) {
            return true; // Item found
        }
        current = current->next;
    }
    return false; // Item not found
}

std::string hashTable::returnItem(int key) {
    int hashIndex = hashFunction(key);
    Node* current = programCourses[hashIndex];

    while (current != nullptr) {
        if (current->key == key) {
            return current->data; // Return the item
        }
        current = current->next;
    }
    return ""; // Item not found
}

void hashTable::deleteItem(int key) {
    int hashIndex = hashFunction(key);
    Node* current = programCourses[hashIndex];
    Node* prev = nullptr;

    while (current != nullptr) {
        if (current->key == key) {
            if (prev == nullptr) {
                // Node to delete is the first node
                programCourses[hashIndex] = current->next;
            }
            else {
                // Node to delete is not the first node
                prev->next = current->next;
            }
            delete current; // Free memory
            return;
        }
        prev = current;
        current = current->next;
    }
}

