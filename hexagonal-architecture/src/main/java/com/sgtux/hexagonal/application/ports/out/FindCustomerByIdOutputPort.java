package com.sgtux.hexagonal.application.ports.out;

import java.util.Optional;

import com.sgtux.hexagonal.application.core.domain.Customer;

public interface FindCustomerByIdOutputPort {

    Optional<Customer> find(String id);
}
