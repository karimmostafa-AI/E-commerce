from abc import ABC, abstractmethod

class Shippable(ABC):
    @abstractmethod
    def get_name(self):
        pass

    @abstractmethod
    def get_weight(self):
        pass
