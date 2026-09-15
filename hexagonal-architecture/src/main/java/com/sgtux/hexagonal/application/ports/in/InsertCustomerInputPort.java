package com.sgtux.hexagonal.application.ports.in;

import com.sgtux.hexagonal.application.core.domain.Customer;

public interface InsertCustomerInputPort {
    void insert(Customer customer, String zipCode);
}
