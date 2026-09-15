package com.sgtux.hexagonal.application.core.usecase;

import com.sgtux.hexagonal.application.ports.in.DeleteCustomerByIdInputPort;
import com.sgtux.hexagonal.application.ports.in.FindCustomerByIdInputPort;
import com.sgtux.hexagonal.application.ports.out.DeleteCustomerByIdOutputPort;

public class DeleteCustomerbyIdUseCase implements DeleteCustomerByIdInputPort {

    private final FindCustomerByIdInputPort findCustomerByIdInputPort;


    private final  DeleteCustomerByIdOutputPort deleteCustomerByIdOutputPort;

    public DeleteCustomerbyIdUseCase(FindCustomerByIdInputPort findCustomerByIdInputPort, DeleteCustomerByIdOutputPort deleteCustomerByIdOutputPort) {
        this.findCustomerByIdInputPort = findCustomerByIdInputPort;
        this.deleteCustomerByIdOutputPort = deleteCustomerByIdOutputPort;
    }

    public void delete(String id) {
        findCustomerByIdInputPort.find(id);
        deleteCustomerByIdOutputPort.delete(id);
    }
}