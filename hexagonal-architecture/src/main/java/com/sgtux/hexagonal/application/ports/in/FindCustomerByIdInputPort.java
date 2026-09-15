package com.sgtux.hexagonal.application.ports.in;

import com.sgtux.hexagonal.application.core.domain.Customer;

public interface FindCustomerByIdInputPort {
    Customer find(String id);
}