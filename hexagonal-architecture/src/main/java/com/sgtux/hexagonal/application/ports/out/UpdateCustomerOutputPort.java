package com.sgtux.hexagonal.application.ports.out;

import com.sgtux.hexagonal.application.core.domain.Customer;

public interface UpdateCustomerOutputPort {

    void update(Customer customer);
    
}
