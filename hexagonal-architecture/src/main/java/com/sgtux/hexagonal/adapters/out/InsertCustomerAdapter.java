package com.sgtux.hexagonal.adapters.out;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;

import com.sgtux.hexagonal.adapters.out.repository.CustomerRepository;
import com.sgtux.hexagonal.adapters.out.repository.mapper.CustomerEntityMapper;
import com.sgtux.hexagonal.application.core.domain.Customer;
import com.sgtux.hexagonal.application.ports.out.InsertCustomeroutputPort;

@Component
public class InsertCustomerAdapter implements InsertCustomeroutputPort {

    @Autowired
    private CustomerRepository customerRepository;

    @Autowired
    private CustomerEntityMapper customerEntityMapper;

    @Override
    public void insert(Customer customer) {
        var customerEntity = customerEntityMapper.toCustomerEntity(customer);
        customerRepository.save(customerEntity);
    }
}