package com.sgtux.hexagonal.adapters.out;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;

import com.sgtux.hexagonal.adapters.out.repository.CustomerRepository;
import com.sgtux.hexagonal.application.ports.out.DeleteCustomerByIdOutputPort;

@Component 
public class DeleteCustomerByIdAdapter implements DeleteCustomerByIdOutputPort {

    @Autowired 
    private CustomerRepository customerRepository;

    @Override
    public void delete(String id) {
        customerRepository.deleteById(id);
    }    
}