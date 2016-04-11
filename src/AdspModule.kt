import dagger.Module
import dagger.Provides
import sorting.InsertionSorter
import sorting.Sorter

@Module
class AdspModule {
    @Provides fun provideSorter(): Sorter = InsertionSorter()
}