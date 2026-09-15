package com.sgtux.hexagonal.application.ports.out;

import com.sgtux.hexagonal.application.core.domain.Customer;

public interface InsertCustomeroutputPort {
    void insert(Customer customer);
}
